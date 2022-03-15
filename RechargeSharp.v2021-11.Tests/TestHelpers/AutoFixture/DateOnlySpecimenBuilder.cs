using System;
using AutoFixture;
using AutoFixture.Kernel;
using Moq;

namespace RechargeSharp.v2021_11.Tests.TestHelpers.AutoFixture;

public class DateOnlySpecimenBuilder : ISpecimenBuilder
{
    private readonly Random random;

    public DateOnlySpecimenBuilder()
    {
        this.random = new Random();
    }

    public object Create(object request, ISpecimenContext context)
    {
        if ((request as Type) == typeof(DateOnly))
            return DateOnly.FromDateTime(DateTime.Today + TimeSpan.FromDays(random.Next(-200, 200)));
        return new NoSpecimen();
    }
}