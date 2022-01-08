﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Query.Mappings;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class WorkOrderDto : IMapFrom<WorkOrder>
{
    private string? _jobStatusCode;
    public string? Plant { get; set; }
    public string? PlantName { get; set; }
    public string? ProjectName { get; set; }
    public string? WoNo { get; set; }
    public string? CommPkgNo { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? MileStoneCode { get; set; }
    public string? MilestoneDescription { get; set; }
    public string? MaterialStatusCode { get; set; }
    public string? CategoryCode { get; set; }
    public string? HoldByCode { get; set; }
    public string? ResponsibleCode { get; set; }
    public string? ResponsibleDescription { get; set; }
    public string? AreaCode { get; set; }
    public string? AreaDescription { get; set; }
    public string? JobStatusCode
    {
        get => _jobStatusCode;
        set  {
        _jobStatusCode = value;

        JobStatusCutoffs = GetJobStatusCutoff(value);
        }
    }

    public string? TypeOfWorkCode { get; set; }
    public string? OnShoreOffShoreCode { get; set; }
    public string? WoTypeCode { get; set; }
    public string? ProjectProgress { get; set; }
    public string? ExpendedManHours { get; set; }
    public string? CreatedAt { get; set; }
    public string? LastUpdated { get; set; }

    public IEnumerable<JobStatusCutoff> JobStatusCutoffs { get; set; } 


    private static IEnumerable<JobStatusCutoff> GetJobStatusCutoff(string? status)
    {
      
        return status switch
        {
            "W01" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status="W01",
                    Weeks = "03/15/2021,03/22/2021,03/29/2021,04/05/2021,04/12/2021,04/19/2021,04/26/2021,05/03/2021,05/10/2021,05/17/2021,05/24/2021,05/31/2021,06/07/2021,06/14/2021,06/21/2021,06/28/2021,07/05/2021,07/12/2021,07/19/2021,07/26/2021,08/02/2021,08/09/2021,08/16/2021,08/23/2021,08/30/2021,09/06/2021".Split(",").ToList()
                }
            },

            "W02" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status="W01",
                    Weeks = "04/13/2020,04/20/2020".Split(",").ToList()
                },
                new()
                {
                    Status="W02",
                    Weeks = "04/27/2020,05/04/2020,05/11/2020,05/18/2020,05/25/2020,06/01/2020,06/08/2020,06/15/2020,06/22/2020,06/29/2020,07/06/2020,07/13/2020,07/20/2020,07/27/2020,08/03/2020,08/10/2020,08/17/2020,08/24/2020,08/31/2020,09/07/2020,09/14/2020,09/21/2020,09/28/2020,10/05/2020,10/12/2020,10/19/2020,10/26/2020,11/02/2020,11/09/2020,11/16/2020,11/23/2020,11/30/2020,12/07/2020,12/14/2020,12/21/2020,12/28/2020,01/04/2021,01/11/2021,01/18/2021,01/27/2021,02/01/2021,02/08/2021,02/15/2021,02/22/2021,03/01/2021,03/08/2021,03/15/2021,03/22/2021,03/29/2021,04/05/2021,04/12/2021,04/19/2021,04/26/2021,05/03/2021,05/10/2021,05/17/2021,05/24/2021,05/31/2021,06/07/2021,06/14/2021,06/21/2021,06/28/2021,07/05/2021,07/12/2021,07/19/2021,07/26/2021,08/02/2021,08/09/2021,08/16/2021,08/23/2021,08/30/2021,09/06/2021".Split(",").ToList()
                }
            },

            "W03" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status = "W03",
                    Weeks = new List<string>
                    {
                        "06/07/2021",
                        "06/14/2021",
                        "06/21/2021",
                        "06/28/2021",
                        "07/05/2021",
                        "07/12/2021",
                        "07/19/2021",
                        "07/26/2021",
                        "08/02/2021",
                        "08/09/2021",
                        "08/16/2021",
                        "08/23/2021",
                        "08/30/2021",
                        "09/06/2021"
                    }
                }
            },

            "W04" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status = "W04",
                    Weeks = "04/13/2020,04/20/2020,04/27/2020,05/04/2020,05/11/2020,05/18/2020,05/25/2020,06/01/2020,06/08/2020,06/15/2020,06/22/2020,06/29/2020,07/06/2020,07/13/2020,07/20/2020,07/27/2020,08/03/2020,08/10/2020,08/17/2020,08/24/2020,08/31/2020,09/07/2020,09/14/2020,09/21/2020,09/28/2020,10/05/2020,10/12/2020,10/19/2020,10/26/2020,11/02/2020,11/09/2020,11/16/2020,11/23/2020,11/30/2020,12/07/2020,12/14/2020,12/21/2020,12/28/2020,01/04/2021,01/11/2021,01/18/2021,01/27/2021,02/01/2021,02/08/2021,02/15/2021,02/22/2021,03/01/2021,03/08/2021,03/15/2021,03/22/2021,03/29/2021,04/05/2021,04/12/2021,04/19/2021,04/26/2021,05/03/2021,05/10/2021,05/17/2021,05/24/2021,05/31/2021,06/07/2021,06/14/2021,06/21/2021,06/28/2021,07/05/2021,07/12/2021,07/19/2021,07/26/2021,08/02/2021,08/09/2021,08/16/2021,08/23/2021,08/30/2021,09/06/2021".Split(",").ToList()
                }
            },

            "W05" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status = "W03",
                    Weeks = new List<string>
                    {
                        "06/01/2020",
                        "06/08/2020",
                        "06/15/2020",
                        "06/22/2020",
                        "06/29/2020",
                        "07/06/2020",
                        "07/13/2020",
                        "07/20/2020",
                        "07/27/2020",
                        "08/03/2020",
                        "08/10/2020",
                        "08/17/2020",
                        "08/24/2020",
                        "08/31/2020"
                    },
                },
                new()
                {
                    Status = "W05",
                    Weeks = new List<string>
                    {
                        "09/07/2020",
                        "09/14/2020",
                        "09/21/2020",
                        "09/28/2020",
                        "10/05/2020",
                        "10/12/2020",
                        "10/19/2020",
                        "10/26/2020",
                        "11/02/2020",
                        "11/09/2020",
                        "11/16/2020",
                        "11/23/2020",
                        "11/30/2020",
                        "12/07/2020",
                        "12/14/2020",
                        "12/21/2020",
                        "12/28/2020",
                        "01/04/2021",
                        "01/11/2021",
                        "01/18/2021",
                        "01/27/2021",
                        "02/01/2021",
                        "02/08/2021",
                        "02/15/2021",
                        "02/22/2021",
                        "03/01/2021",
                        "03/08/2021",
                        "03/15/2021",
                        "03/22/2021",
                        "03/29/2021",
                        "04/05/2021",
                        "04/12/2021",
                        "04/19/2021",
                        "04/26/2021",
                        "05/03/2021",
                        "05/10/2021",
                        "05/17/2021",
                        "05/24/2021",
                        "05/31/2021",
                        "06/07/2021",
                        "06/14/2021",
                        "06/21/2021",
                        "06/28/2021",
                        "07/05/2021",
                        "07/12/2021",
                        "07/19/2021",
                        "07/26/2021",
                        "08/02/2021",
                        "08/09/2021",
                        "08/16/2021",
                        "08/23/2021",
                        "08/30/2021",
                        "09/06/2021"
                    }
                }
            },

            "W06" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status="W04",
                    Weeks = "05/11/2020,05/18/2020,05/25/2020,06/01/2020,06/08/2020,06/15/2020,06/22/2020,06/29/2020,07/06/2020,07/13/2020,07/20/2020,07/27/2020,08/03/2020,08/10/2020,08/17/2020,08/24/2020,08/31/2020,09/07/2020,09/14/2020,09/21/2020,09/28/2020,10/05/2020".Split(",").ToList()
                },
                new()
                {
                    Status = "W06",
                    Weeks =  "04/13/2020,04/20/2020,04/27/2020,05/04/2020,10/12/2020,10/19/2020,10/26/2020,11/02/2020,11/09/2020,11/16/2020,11/23/2020,11/30/2020,12/07/2020,12/14/2020,12/21/2020,12/28/2020,01/04/2021,01/11/2021,01/18/2021,01/27/2021,02/01/2021,02/08/2021,02/15/2021,02/22/2021,03/01/2021,03/08/2021,03/15/2021,03/22/2021,03/29/2021,04/05/2021,04/12/2021,04/19/2021,04/26/2021,05/03/2021,05/10/2021,05/17/2021,05/24/2021,05/31/2021,06/07/2021,06/14/2021,06/21/2021,06/28/2021,07/05/2021,07/12/2021,07/19/2021,07/26/2021,08/02/2021,08/09/2021,08/16/2021,08/23/2021,08/30/2021,09/06/2021".Split(",").ToList()
                }
            },

            "W08" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status = "W08",
                    Weeks = "04/13/2020,04/20/2020,04/27/2020,05/04/2020,05/11/2020,05/18/2020,05/25/2020,06/01/2020,06/08/2020,06/15/2020,06/22/2020,06/29/2020,07/06/2020,07/13/2020,07/20/2020,07/27/2020,08/03/2020,08/10/2020,08/17/2020,08/24/2020,08/31/2020,09/07/2020,09/14/2020,09/21/2020,09/28/2020,10/05/2020,10/12/2020,10/19/2020,10/26/2020,11/02/2020,11/09/2020,11/16/2020,11/23/2020,11/30/2020,12/07/2020,12/14/2020,12/21/2020,12/28/2020,01/04/2021,01/11/2021,01/18/2021,01/27/2021,02/01/2021,02/08/2021,02/15/2021,02/22/2021,03/01/2021,03/08/2021,03/15/2021,03/22/2021,03/29/2021,04/05/2021,04/12/2021,04/19/2021,04/26/2021,05/03/2021,05/10/2021,05/17/2021,05/24/2021,05/31/2021,06/07/2021,06/14/2021,06/21/2021,06/28/2021,07/05/2021,07/12/2021,07/19/2021,07/26/2021,08/02/2021,08/09/2021,08/16/2021,08/23/2021,08/30/2021,09/06/2021".Split(",").ToList()
                }
            },

            "W09" => new List<JobStatusCutoff>
            {
                new()
                {
                    Status = "W08",
                    Weeks = "12/07/2020,12/14/2020,12/21/2020,12/28/2020,01/04/2021,01/11/2021,01/18/2021,01/27/2021,02/01/2021,02/08/2021,02/15/2021,02/22/2021,03/01/2021,03/08/2021,03/15/2021,03/22/2021,03/29/2021,04/05/2021,04/12/2021,04/19/2021,04/26/2021,05/03/2021,05/10/2021,05/17/2021,05/24/2021,05/31/2021,06/07/2021,06/14/2021,06/21/2021,06/28/2021,07/05/2021,07/12/2021,07/19/2021,07/26/2021,08/02/2021,08/09/2021,08/16/2021,08/23/2021,08/30/2021,09/06/2021".Split(",").ToList()
                }
            },

            _ => new List<JobStatusCutoff>()

        };
    }
    //TODO static feeded list of statuses with weeks.
}
