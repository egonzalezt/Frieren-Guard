# Frieren's Guardian Library: Your System's Sentinel

## Inspiration

This library's name takes inspiration from the anime "Frieren: Beyond Journey's End." In the anime, Frieren is an elven mage on a journey to fulfill promises made to her departed friends. Frieren's Guardian Library draws from Frieren's wisdom, patience, and ability to overcome challenges, with the goal of protecting your system from errors and failures.

## Description

Frieren's Guardian Library is an open-source tool designed to help protect your system from errors and failures. The library performs health checks, monitors your system, and notifies users when it detects an issue.

## Features:

### Health Checks

* Frieren's Guardian can execute a variety of health checks that use the .NET standard [IHealthCheck](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-8.0#create-health-checks)

* Notifications: Frieren's Guardian can alert different workers or libraries when a system is unhealthy.

* Create Health Notifications: Frieren support to generate notifications from other workers to notify if there is an exception during execution e.g. database or external Api not available without waiting the predefined seconds to execute the health check.

## License

Frieren Guard is licensed under the [Apache 2.0 license](./LICENSE).