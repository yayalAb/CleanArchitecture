using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Deriver.Commands.Create;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Driver.CommandsTest;

using static Testing;

public class CreateCommadTest : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateDriverCommands();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
}
