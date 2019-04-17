using System;
using System.Text;
using Deoxys;
using Deoxys.Rovers;
using Deoxys.Planets;
using Deoxys.Console.UI.Report;
using Deoxys.Console.UI.Command;
using Deoxys.Console.UI.Command.Interpret;
using System.Reflection;
using Autofac;
using Deoxys.Mars;
using Deoxys.Rovers.Report;

namespace Deoxys.Console.UI
{
    class Program
    {
        private static CommandCenter _commandCenter;

        static Program()
        {
            using (IContainer container = CreateContainerBuilder()
                .Build())
            {
                _commandCenter = container.Resolve<CommandCenter>();
            }
        }

        static void Main(string[] args)
        {
            string cmd = CreateCommand().ToString();
            System.Console.WriteLine("Test Input:");
            System.Console.WriteLine(cmd);
            System.Console.WriteLine("");
            System.Console.WriteLine("Output:");

            _commandCenter
                .Parse(cmd)
                .Execute()
                .LogWrite();

            System.Console.Read();
        }


        /// <summary>
        /// app için kullanıcal olan ioc leri container a ekliyor
        /// </summary>
        /// <returns></returns>
        private static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CommandCenter>()
                .As<CommandCenter>();
            builder.RegisterType<InputParser>()
                .As<InputParser>();

            builder.Register<Func<Point, DirectionType, IRover>>((context) =>
            {
                return (location, direction) =>
                {
                    return new MarsRover(location, direction);
                };
            }).As<Func<Point, DirectionType, IRover>>();
            builder.Register<Func<Size, IPlanet>>((context) =>
            {
                return (size) =>
                {
                    return new MarsPlanet(size);
                };
            }).As<Func<Size, IPlanet>>();
            builder.Register<Func<IRover, IRoverReport>>((context) =>
             {
                 return (rover) =>
                 {
                     return new RoverConsoleReport(rover);
                 };
             }).As<Func<IRover, IRoverReport>>();

            return builder;
        }


        /// <summary>
        /// hazır komut oluşturur
        /// </summary>
        /// <returns>string şekilde komut dizini döner</returns>
        private static StringBuilder CreateCommand()
        {
            StringBuilder commands = new StringBuilder();

            commands.AppendLine("5 5");
            commands.AppendLine("1 2 N");
            commands.AppendLine("LMLMLMLMM");
            commands.AppendLine("3 3 E");
            commands.Append("MMRMMRMRRM");

            return commands;
        }
    }
}
