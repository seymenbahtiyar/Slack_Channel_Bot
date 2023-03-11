# Slack Channel Bot

Slack Channel Bot is a C# console application that listens for messages in a specific Slack channel and responds to them based on certain keywords. It uses the [RestSharp](https://restsharp.dev/) library for making API requests to the [Slack API](https://api.slack.com/methods).

## Setup

1. Create a new bot(app) in your Slack workspace and generate a bot token for it. And you must add the necessary bot scopes.
2. Set the `slackBotToken`, `slackChannelIDForListen`, and `slackBotUserID` variables in the `Program.cs` file to the appropriate values for your Slack bot and channel.
3. Run the application.

## Usage

The SlackChannelBot listens for incoming messages in the specified Slack channel and responds to them based on certain keywords.

### Available Commands

- `-help`: Shows a list of available commands.

### Example Usage

User: `Hello!`

   Bot: 

<img width="240" alt="image" src="https://user-images.githubusercontent.com/110940406/224450922-0964f691-d4da-4f05-aa21-7a3ea63c3a23.png">



## Methods

- `Main(string[] args)`: The entry point of the application. Initializes the application and starts listening for incoming messages.
- `GetLastMessage()`: Retrieves the timestamp of the last message received in the specified Slack channel.
- `ListenForMessages()`: Listens for incoming messages in the specified Slack channel and responds to them based on certain keywords.
- `SendMessage(string userId, string text)`: Sends a message to the specified user in the specified Slack channel.

## Variables

- `slackBotToken`: The bot token for authentication.
- `lastMessageTimestamp`: A variable to store the timestamp of the last message received.
- `slackChannelIDForListen`: The ID of the Slack channel where the bot will listen for incoming messages.
- `slackBotUserID`: The ID of the Slack bot user.
- `slackBaseURL`: The base URL for the Slack API.

## License

[MIT](https://github.com/seymenbahtiyar/Slack_Channel_Bot/blob/main/LICENSE)
