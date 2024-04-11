using Xunit;
using DPizza.Domain;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class ArchitectureTests
{

    private const string DomainNamespace = "DPizza.Domain";
    private const string ApplicationNamespace = "DPizza.Application";
    private const string InfrastructureNamespace = "DPizza.Infrastructure";
    private const string PresentationNamespace = "DPizza.Presentation";

    [Fact]
    public void Domain_should_not_haveDependancyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(DPizza.Domain.Common.BaseEntity).Assembly;

        var otherProjects = new[]
        {
         ApplicationNamespace, InfrastructureNamespace, PresentationNamespace
        };

        //Act

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        //Assert

        testResult.IsSuccessful.Should().BeTrue();
    }
}

