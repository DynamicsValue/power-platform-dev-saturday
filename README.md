# Power Platform Developer Saturday with FakeXrmEasy
----------------------------------------------------

This is the sample repo for Power Platform Developer Saturday session about What's new in FakeXrmEasy.

This sample project demonstrates how to use Microsoft's new CdsServiceClient nuget package along with FakeXrmEasy to unit test the backend of an aspnet core application that talks to CDS (Common Data Service).

It's based on [Colin's CdsWeb sample](https://github.com/CdsWeb-app/). This sample just adds a unit test project and a react frontend to showcase some basic unit tests of CRUD operations as demo of what's coming in FakeXrmEasy v2.

The new nuget package along with FakeXrmEasy on .net core opens up endless possibilities of testing a bunch of different client applications:

- .net core console apps
- aspnet core
- azure functions (.net core)
- etc

Plus the ability that those applications could be easily containerised and run in a Kubernetes cluster.

## Layout

## Prerequisites

In order to run this application you'll need a Common Data Service intance, and register both an App on Azure and an Application User that can be used to authenticate using an AuthType=ClientSecret connection string.

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






