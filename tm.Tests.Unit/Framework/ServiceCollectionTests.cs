using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace tm.Tests.Unit.Framework;

public class ServiceCollectionTests
{
    [Fact]
    public void test()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IMessenger, Messenger>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var messenger = serviceProvider.GetRequiredService<IMessenger>();
        messenger.Send();
        var messenger2 = serviceProvider.GetRequiredService<IMessenger>();
        messenger2.Send();

        messenger.ShouldNotBeNull();
        messenger2.ShouldNotBeNull();

        messenger.ShouldBe(messenger2);
    }

    public interface IMessenger
    {
        void Send();
    }

    private class Messenger : IMessenger
    {
        private readonly Guid _id = Guid.NewGuid();

        public void Send() => Console.WriteLine($"Sending a message ... {_id}");
    }
}
