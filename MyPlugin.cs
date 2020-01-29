using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace EntityTSCreator
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Entity TS files creator"),
        ExportMetadata("Description", "This tool is to create .ts (TypeScript) model files to be used in front end project like Angular."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAASzSURBVFhH7VZ7bFN1FP7a3ra3t93Y2MZ0qzCmY2bCIjAzM+JgPkLQGDExyj/GxGAMEqP/iCaL8f3AgPEvjSH4B1FjNBF8ZEpgigPmQBbAgFNkwsZkW+m6rutuH7cPzzld5xW7ZjMxmLjv5uT23nt+536/7zxuLZ1jg2lcQVgnz1cMcwT+WwSsVuuszGKxiDHS6UwtW+i+TbGJWW3kY/27jxmmLrBAHw/DaiFOGf+84GB2p4POKSiKHQ7VQeZEYHgEoUBQiKguFU6XM/Pb7UI6lULCSEwRYggBZhmPxvHyg0/DSYHII/M0V4PyI7qfTCTQfO8ddE5i9f1rMXz+d3yx4xMEhvxyj91YAZfHjbrGepR5r4K3ZiG8S6oQnYhMkchdA/xiMgexLyguFHN5XHKtKMqfPgTe2Q9fH8K7z7yJSFiHg1RxF3rIVxUCbN3t38N3YQi/HDuNM90/iU92b1MpoExhglNAcjGcJGfnlwfQ9VUHBbGhqu5alC+swLySIlzfsBTxeFwIIZXG9k0vCJFYNIr6ppVwFxVg8Q01ktKPtr2HorL5SLBi99xG79Bx8523UGpUSeOUAmk6PPMKoBW44SLjIIrTnikcMsWuSM4dmhNakQca7dKpqhgZ9lP6YkhRfr3XVaF8UQWppaF2RR0aVjdh+ZpGqgs/gr4ALlKauGYGey+IMoy/pICDiCWTYmnanYDSxfe5iPheKpnx4WsbpYQ5ck71UJhI2mEQIV4Z1sdx64Z1ePj5x/HIK09i1d0tWN7SiPKqSonByF0Dl0NekHE1t1KSSFRWe1FcXiLExkZGKWUHEdOjOPz5N9DDYZF/yco6LF5ag9LKBSgqLRaFsnFmRoAUYOkYVlMLcRAjnsDGl57AqM8vRMcDYzi6rxMde/bjw9d34tDudpzqPIHx0ZCkUJQ0bWLWCtByOTNY9oRhwEM18eqet7GICjVCLcYtmowbokj7x23oavsOx789gmN7D0vKzJi9AnxhQoZEgqrcwEOtj+GpHS9i/aYNKLvmagQvjUpLDp4bwPlTZxGNxKQl7ap9cvU/UcAkH//iScedo2oaolEdLmrH+uYGbH5tC559/w1E9YhMyIHePukWTpGvbyh3F+RDVgHzGHXTiz/YuhPbHn0OWze2ovOzA+j4dB98A8MIhYMywNbctxYx2jnPFx7RTCZ4KSDjmTFjAjm7gHJdUlFGuwpR68XRd+Y3aG4NF8/2w+OhmWLxwNc/BBvtltdZrbbJM8WajDNjAtkFZgXiMQPN62+ncxyKw47+nnM4ebAbvSd/Rtuu3dj11js43XVCnnG+ihfMlxYt9ZZLNzDyEmC2MnS4dfiga7MCPIy4pzdv3wJ9bFw6wj/ow6/He3CERnjP0R9F8siEjmWrVgjR6mU1MguyQ25aAily4ELhycY7sNH3QP4DkGVJsBqxSFTGbysVXMsD66TquRXli0dHIX07mu5qQfWNtTQFb0J1fa0QyWLaf8X8Eq5oVdH4CgYd/EHhT61BAcypYF8mx2RVhwY7HQzSDtSgSKRoNc0FXsuqmdfm/VtultsMc4DLMd0aRq51eWuAF+SyfMjln7VcmHkX/EuYIzBH4P9OAPgDB7w0j4/mnoYAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}