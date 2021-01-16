# Asp.Net Core OData Examples

This repo contains various examples which use the ASP.NET Core ODATA library.

## Examples
### Non-EDM Approach (/NonEdmApproach)
This example uses the "non-EDM" approach to using the ODATA library. This forgoes the EDM data model and instead simply uses `ODataQueryOptions<T>` as a controller parameter.

The following URLs should work;
|   URL   |  Example | Description |
| ------- | -------- | ----------- |
| `/api/accounts` | `/api/accounts` | Lists all accounts |
| `/api/accounts/{id}` | `/api/accounts/1C82F39E-462E-4E76-AC84-7FB9CA4827B9` | Gets data for a single account |
| `/api/accounts/{id}/users` | `/api/accounts/1C82F39E-462E-4E76-AC84-7FB9CA4827B9/users` | Gets users within an account |
| `/api/accounts/{accountId}/users/{userId}` | `/api/accounts/1C82F39E-462E-4E76-AC84-7FB9CA4827B9/users/229CF8C1-830E-4B7F-9F9D-69B4224B0514` | Gets a user within an account |

To call the endpoints you must supply a bearer token; if the token is `abc` you will be able to access all accounts and all users whose `GroupName` is `Retail`. Any other bearer token will allow you to access all accounts and users in the `CustomerSupport` group.

Data is in memory and seeded on application startup.