# AWS-Practice
All my Amazon Web Service practice works are included in this repo.
The codes are done using AWS SDK. We used the following NuGet packages
for our works:

| Services   |      NuGet Package Used      | 
|----------  |:----------------------------:|
| Dynamo DB  |  AWSSDK.DynamoDBv2           | 
| S3 Bucket  |    AWSSDK.S3                 |
| SQS        | AWSSDK.SQS                   |

## Demo

![Amazon S3 File Upload](/docs/images/AmazonS3.jpg "Amazon S3 File Upload")

## Installation

First, you need to configure your account: 

Configure AWS using CLI
```
aws configure
AWS Access Key ID [None]: AKIAIOSFODNN7EXAMPLE
AWS Secret Access Key [None]: wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY
Default region name [None]: us-west-2
Default output format [None]: json

```
_[N:B: These dummy config details taken from AWS docs.]_

Provide credentials which you have got from your AWS account. 

⚠️ **Warning! NEVER EVER put your AWS Credentials in `appsettings.json` or `Program.cs` file.**

## My AWS Blogs

Read some of my writings related to AWS - 

- [Beginner's Guide to AWS CLI: Download, Install & Configure](https://nayeemsweb.hashnode.dev/beginners-guide-to-aws-cli-download-install-and-configure)

![AWS CLI Installation & Configuration](/docs/images/AwsCliInstallation.png "Learn how to Download, Install AWS CLI and Configure the AWS account credentials in AWS CLI.")

- [Hands-on AWS CLI Basics : S3](https://nayeemsweb.hashnode.dev/hands-on-aws-cli-basics)

![AWS CLI Installation & Configuration](/docs/images/HandsOnAwsCli.png "Learn Practically AWS CLI: List S3 Buckets, Create S3 Bucket, Upload File, Delete File & Delete Bucket.")
