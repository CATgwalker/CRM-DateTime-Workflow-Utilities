﻿using LAT.WorkflowUtilities.DateTimes.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.DateTimes
{
    public sealed class IsBusinessDay : WorkFlowActivityBase
    {
        public IsBusinessDay() : base(typeof(IsBusinessDay)) { }

        [RequiredArgument]
        [Input("Date To Check")]
        public InArgument<DateTime> DateToCheck { get; set; }

        [Input("Holiday/Closure Calendar")]
        [ReferenceTarget("calendar")]
        public InArgument<EntityReference> HolidayClosureCalendar { get; set; }

        [RequiredArgument]
        [Input("Evaluate As User Local")]
        [Default("True")]
        public InArgument<bool> EvaluateAsUserLocal { get; set; }

        [Output("Valid Business Day")]
        public OutArgument<bool> ValidBusinessDay { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            DateTime dateToCheck = DateToCheck.Get(context);
            bool evaluateAsUserLocal = EvaluateAsUserLocal.Get(context);

            Entity calendar = null;
            EntityReference holidayClosureCalendar = HolidayClosureCalendar.Get(context);
            if (holidayClosureCalendar != null)
                calendar = localContext.OrganizationService.Retrieve("calendar", holidayClosureCalendar.Id, new ColumnSet(true));

            if (evaluateAsUserLocal)
            {
                int? timeZoneCode = GetLocalTime.RetrieveTimeZoneCode(localContext.OrganizationService);
                dateToCheck = GetLocalTime.RetrieveLocalTimeFromUtcTime(dateToCheck, timeZoneCode, localContext.OrganizationService);
            }

            var result = dateToCheck.IsBusinessDay(calendar);

            ValidBusinessDay.Set(context, result);
        }
    }
}