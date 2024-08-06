# Library-API
Api Spec:
## Authentication
Request: 
  Header:
    Authentication : JWT Token
## Controller
### Login:
  Input:
  ```json
    {
    "username": "string",
    "password": string
    }
```
  Response:
  ```json
    {
    "status": "Success",
    "message": "We have sent an OTP to your Email",
    "otp": int
    }
```
### Login 2-fa
Input:
```json
"otp" : int,
"username": string
```
Response:
```json
{
  "token": string,
  "expiration": "Date"
}

