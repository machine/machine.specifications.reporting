﻿using Machine.Specifications.Reporting.Integration;
using Machine.Specifications.Reporting.Integration.TeamCity;

namespace Machine.Specifications.Reporting.Specs.Integration
{
    [Subject(typeof(TeamCityServiceMessageWriter))]
    public class when_errors_are_reported
    {
        static string Written;
        static TeamCityServiceMessageWriter Writer;

        Establish context = () => { Writer = new TeamCityServiceMessageWriter(s => Written = s); };

        Because of = () => Writer.WriteError("test failed", "details");

        It should_report_an_error_string =
          () => Written.ShouldEndWith("status=\'ERROR\']");

        It should_report_the_error_message =
          () => { Written.ShouldContain("text=\'test failed\'"); };

        It should_report_error_details =
          () => { Written.ShouldContain("errorDetails=\'details\'"); };
    }

    [Subject(typeof(TeamCityServiceMessageWriter))]
    public class when_special_characters_are_used
    {
        static string Written;
        static TeamCityServiceMessageWriter Writer;

        Establish context = () => { Writer = new TeamCityServiceMessageWriter(s => Written = s); };

        Because of =
          () => Writer.WriteTestFailed("Name abc | ' \n \r ] \u0085 \u2028 \u2029",
                                       "Message abc | ' \n \r ] \u0085 \u2028 \u2029",
                                       "Details abc | ' \n \r ] \u0085 \u2028 \u2029");

        It should_escape_special__name__characters =
          () => Written.ShouldContain("Name abc || |' |n |r |] |x |l |p");

        It should_escape_special__message__characters =
          () => Written.ShouldContain("Message abc || |' |n |r |] |x |l |p");

        It should_escape_special__details__characters =
          () => Written.ShouldContain("Details abc || |' |n |r |] |x |l |p");
    }
}
