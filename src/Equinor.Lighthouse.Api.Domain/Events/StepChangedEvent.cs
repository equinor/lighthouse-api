using System;
using MediatR;

namespace Equinor.Lighthouse.Api.Domain.Events
{
    public class StepChangedEvent : INotification
    {
        public StepChangedEvent(
            string plant,
            Guid objectGuid,
            int fromStepId,
            int toStepId)
        {
            Plant = plant;
            ObjectGuid = objectGuid;
            FromStepId = fromStepId;
            ToStepId = toStepId;
        }
        public string Plant { get; }
        public Guid ObjectGuid { get; }
        public int FromStepId { get; }
        public int ToStepId { get; }
    }
}
