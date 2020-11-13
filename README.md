# 24HourChallenge.WebAPI
# 24 hour eleven fifty challenge

----------------

## First make a user via Postman:
1. Make a post and direct it to https://localhost:{YourLocalHost}/api/Account/Register
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:
  Email             
  Password 
  Confirm Password
4. Send

---------------------

## Get your Token
1. Make a post and direct it to https://localhost:{YourLocalHost}/token
2. Navagate to Body > x.www-form-urlencoded
3. Enter values:
|Key | Value |
|--------|-------:|
 | grant_type | password |
 | username   | {YourEmail}|
 | password   | {YourPassword}|
4. Send
5. Copy the access_token, do not include the quotes

-----------------

Before each endpoint listed below you must first to the following every time:

1.After creating each, navagate to Headers and add the below (Key | Value) to the end of the list:
Authorization    |   Bearer {YourToken}

## [[[POST]]]
### Post a Post
1. Make a Post and driect it to https://localhost:{YourLocalHost}/api/Post
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:
  Title             
  Text
4. Send

### Post a Comment
1. Make a Post and driect it to https://localhost:{YourLocalHost}/api/Comment
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:
  Text             
  PostId
4. Send

### Post a Reply
1. Make a Post and driect it to https://localhost:{YourLocalHost}/api/Reply
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:
  Text             
  CommentId
4. Send

### Post a Like
1. Make a Post and driect it to https://localhost:{YourLocalHost}/api/Like
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:
  PostId
4. Send

## [[[GET]]]

### Get all Posts
1. Make a Get and driect it to https://localhost:{YourLocalHost}/api/Post
2. Send

### Get a Post By Id
1. Decide what post you'd like to see, the PostId = id below
2. Make a Get and driect it to https://localhost:{YourLocalHost}/api/Post/{id}
3. Send

### Get all Comments for Post By Id
1. Decide what post's comments you'd like to see, the PostId = id below
2. Make a Get and driect it to https://localhost:{YourLocalHost}/api/Comment/{id}
3. Send

### Get all Replies for Comment By Id
1. Decide what comments's replies you'd like to see, the CommentId = id below
2. Make a Get and driect it to https://localhost:{YourLocalHost}/api/Reply/{id}
3. Send

## [[[PUT]]]

### Update a Post
1. Decide what post you'd like to update, the PostId = id below
2. Make a Put and driect it to https://localhost:{YourLocalHost}/api/Post/{id}
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:
  Title             
  Text
4. Send

### Update a Comment
1. Decide what Comment you'd like to update, the CommentId = id below
2. Make a Put and driect it to https://localhost:{YourLocalHost}/api/Comment/{id}
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:           
  Text
4. Send

### Update a Reply
1. Decide what post you'd like to Reply, the ReplyId = id below
2. Make a Put and driect it to https://localhost:{YourLocalHost}/api/Reply/{id}
2. Navagate to Body > x.www-form-urlencoded
3. Enter values for the below keys:           
  Text
4. Send

## [[[Delete]]]

### Delete a Post By Id
1. Decide what post you'd like Delete, the PostId = id below
2. Make a Delete and driect it to https://localhost:{YourLocalHost}/api/Post/{id}
3. Send

### Delete a Comment By Id
1. Decide what Comment you'd like Delete, the CommentId = id below
2. Make a Delete and driect it to https://localhost:{YourLocalHost}/api/Comment/{id}
3. Send

### Delete a Reply By Id
1. Decide what Reply you'd like Delete, the ReplyId = id below
2. Make a Delete and driect it to https://localhost:{YourLocalHost}/api/Reply/{id}
3. Send

Delete a Like By Post Id
1. Decide what post you'd like remove a like from, the PostId = id below
2. Make a Delete and driect it to https://localhost:{YourLocalHost}/api/Like/{id}
3. Send
