using Bot.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Managers.Plugins
{
    public class BotPlugin
    {
        public static List<BotPlugin> Plugins = new List<BotPlugin>();

        public string Name { get; set; }

        public string Description => _plugin?.Description ?? string.Empty;

        public string Path { get; set; }

        public string LastError { get; private set; }

        private IBotPlugin _plugin;

        public BotPlugin(string dllPath)
        {
            Path = dllPath;
            Name = System.IO.Path.GetFileName(dllPath);
        }

        private Type[] TryGetTypes(Assembly asm)
        {
            try {
                return asm.GetTypes();
            } catch (ReflectionTypeLoadException e) {
                return e.Types.Where(t => t != null).ToArray();
            }
        }

        public bool Load()
        {
            try {
                if (!File.Exists(Path)) {
                    LastError = $"Could not find file: {Path}";
                    return  false;
                }

                Assembly asm = Assembly.LoadFile(Path);
                Type loader;
                Type[] types;

                if ((types = TryGetTypes(asm)) == null) {
                    LastError = "Unable to retrieve any types in the assembly.";
                    return  false;
                }

                if ((loader = types.FirstOrDefault(t => t.IsDefined(typeof(BotPluginEntry)))) == null) {
                    LastError = "Unable to retrieve types in plugin";
                    return  false;
                }

                _plugin = (IBotPlugin) Activator.CreateInstance(loader);

                _plugin.Load();

                Plugins.Add(this);

                return true;
            } catch(Exception e) {
                LastError = "This is not a bot plugin.\n" + e.Message + "\n" + e.StackTrace;
                return  false;
            }
        }

        public bool Unload()
        {
            try {
                _plugin.Unload();
                Plugins.Remove(this);

                return  true;
            } catch (Exception ex) {
                LastError = "This is not a bot plugin. " + ex.StackTrace;

                return  false;
            }
        }
    }
}
