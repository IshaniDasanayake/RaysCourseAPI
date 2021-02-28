# RaysCourseAPI

## Pre requisites
Install C# (.Net core) & Mysql

- Microsoft SQL Server Management studio
- Visual Studio 
  
## Getting Started
Start mysql server and create database called `RaysCourses DB` in mysql server.

Change the connection string in appsettings.json. 

Install all the packages from NuGet Package manager
`Microsoft.EntityFrameworkCore`
`Microsoft.EntityFrameworkCore.SqlServer`
`MySqlConnector`

Use the following DB script https://github.com/IshaniDasanayake/RaysCourseAPI/blob/master/DB%20script

Start the API server. Default port is `5001`

## How to use APIs
Some APIs given by this application can be called for following purposes as shown below.

localhost 5008/api

#### List Course Types
`GET /api/courseTypes`
| API | Result |
| --- | --- |
| courseTypes | Returns array of all course types |

#### List Courses for types
`GET /api/courses/{id}`
| API | Type | Result |
| --- | --- | --- |
| courses/{id} | int | Returns array of all course for course type id |

#### Add new Course
`POST /api/insertCourse`
| API | Input| Result |
| --- | --- | --- |
| insertCourse | FormBody | Insert form values to database |

#### Update existing Course
`POST /api/updateCourse`
| API | Input| Result |
| --- | --- | --- |
| updateCourse | FormBody | Update database values |

#### Delete Course
`GET /api/deleteCourse/{id}`
| API | Type| Result |
| --- | --- | --- |
| deleteCourse/{id} | int | Update the `is_active` column as 0 |

#### Student Enrol
`POST /api/enrol`
| API | Input| Result |
| --- | --- | --- |
| enrol | FormBody | Insert form values to database |


