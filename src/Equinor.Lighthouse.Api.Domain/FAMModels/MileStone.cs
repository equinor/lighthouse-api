using System;


namespace Equinor.Lighthouse.Api.Domain.FAMModels;

public struct Milestone
{
    string Code;
    DateTime Planned;
    DateTime Actual;
}
