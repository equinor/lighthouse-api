using System;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;

public class Setting : PlantEntityBase, IAggregateRoot
{
    public static string LastAcceptedCertificatesReadCode => "LastAcceptedCertificatesRead";
    public static string LastAcceptedCertificatesReadingCode => "LastAcceptedCertificatesReading";
    public const int CodeLengthMax = 64;

    protected Setting()
        : base(null)
    {
    }

    public Setting(string plant, string code) : base(plant) => Code = code;

    public string Code { get; private set; }
    public DateTime? DateTimeUtc { get; private set; }

    public void SetDateTime(DateTime? dateTimeUtc)
    {
        if (dateTimeUtc.HasValue && dateTimeUtc.Value.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException($"{nameof(dateTimeUtc)} is not Utc");
        }

        DateTimeUtc = dateTimeUtc;
    }
}