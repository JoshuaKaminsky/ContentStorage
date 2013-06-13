using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("ContentStorage")]
[assembly: AssemblyDescription("")]

[assembly: ComVisible(false)]

[assembly: Guid("2d4eb643-5ff8-4518-8e4b-91466c24344b")]

[assembly: InternalsVisibleTo("ContentStorage.Bootstrap.Autofac")]
[assembly: InternalsVisibleTo("ContentStorage.Bootstrap.CastleWindsor")]
[assembly: InternalsVisibleTo("ContentStorage.Bootstrap.Ninject")]
[assembly: InternalsVisibleTo("ContentStorage.Bootstrap.Unity")]

[assembly: InternalsVisibleTo("ContentStorage.Test")]

//This allows me to mock internal interfaces
[assembly:InternalsVisibleTo("DynamicProxyGenAssembly2")] 