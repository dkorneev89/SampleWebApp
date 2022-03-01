# SampleWebApp
### Description

* the application responds to a GET request of the form:
```/request/<data>```
with a json of the form:
```javascript
{
    "echo": "<data>"
}
```
* uses a middleware that logs the request (HTTP verb, path, UTC time)
* with a 50 percent chance returns with 404
