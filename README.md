# Power Platform Developer Saturday with FakeXrmEasy
----------------------------------------------------

This is the sample repo for Power Platform Developer Saturday (365portal.org)

This sample project demonstrates how to use Microsoft's new CdsServiceClient nuget package along with FakeXrmEasy to unit test the backend of an aspnet core application that talks to CDS (Common Data Service)

## Layout

## Prerequisites

In order to run this application you'll need a Common Data Service intance, and setup an Application User that can be used to authenticate using an AuthType=ClientSecret connection string.

@BetimBeja has written an excellent article which explains how to setup the ApplicationUser [on this LinkedIn post](https://www.linkedin.com/pulse/microsoftpowerplatformcdsclient-betim-beja/)

Add a new appsettings.Development.json config file with the ConnectionString once you have setup the ApplicationUser and you should be good to go.

    "CdsServiceClient": {
      "ConnectionString": "<YourConnectionStringHere>",
      "IncludeOrganizationServiceContext": true,
      "TraceLevel": "Off"
    }

## Building

    dotnet build

## Running Tests

    dotnet test

## Running the application

    dotnet run --project src/web

Application will be running on https://localhost:5001






