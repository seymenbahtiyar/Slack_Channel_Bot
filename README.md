# Slack_Channel_Bot

Slack_Channel_Bot is a C# console application that listens for messages in a specific Slack channel and responds to them based on certain keywords. It uses the [RestSharp](https://restsharp.dev/) library for making API requests to the Slack API.

## Setup

1. Create a new bot in your Slack workspace and generate a bot token for it.
2. Set the `slackBotToken`, `slackChannelIDForListen`, and `slackBotUserID` variables in the `Program.cs` file to the appropriate values for your Slack bot and channel.
3. Run the application.

## Usage

The SlackChannelBot listens for incoming messages in the specified Slack channel and responds to them based on certain keywords.

### Available Commands

- `-help`: Shows a list of available commands.

### Example Usage

1. User: `Hello!`
   Bot: `Hello! :hand: How can I help you? :cool_thinking_blob:`

2. User: `-help`
   Bot: `Commands : \n-help`

## Code Reference

### Classes

- `Program`: The main class that contains the application logic.

### Methods

- `Main(string[] args)`: The entry point of the application. Initializes the application and starts listening for incoming messages.
- `GetLastMessage()`: Retrieves the timestamp of the last message received in the specified Slack channel.
- `ListenForMessages()`: Listens for incoming messages in the specified Slack channel and responds to them based on certain keywords.
- `SendMessage(string userId, string text)`: Sends a message to the specified user in the specified Slack channel.

### Variables

- `slackBotToken`: The bot token for authentication.
- `lastMessageTimestamp`: A variable to store the timestamp of the last message received.
- `slackChannelIDForListen`: The ID of the Slack channel where the bot will listen for incoming messages.
- `slackBotUserID`: The ID of the Slack bot user.
- `slackBaseURL`: The base URL for the Slack API.

## License

[MIT](https://github.com/seymenbahtiyar/Slack_Channel_Bot/blob/main/LICENSE)
