namespace Equinor.Lighthouse.Api.Command;

public class RequirementForCommand
{
    public RequirementForCommand(int requirementDefinitionId, int intervalWeeks)
    {
        RequirementDefinitionId = requirementDefinitionId;
        IntervalWeeks = intervalWeeks;
    }

    public int RequirementDefinitionId { get;  }
    public int IntervalWeeks { get; }
}