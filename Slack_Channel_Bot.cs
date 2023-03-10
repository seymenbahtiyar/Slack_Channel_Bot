// RestSharp version 108.0.3

using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using RestSharp.Authenticators;

namespace SlackBotDemo
{
    class Program8
    {
        // Setting up required parameters
        static string slackBotToken = "token"; // Bot token for authentication
        static string lastMessageTimestamp = ""; // Variable to store the timestamp of the last message received
        static string slackChannelIDForListen = "channelID"; // Channel ID where the bot will listen for incoming messages
        static string slackBotUserID = "BotID"; // Bot user ID
        static string slackBaseURL = "https://slack.com/api"; // Base URL for Slack API

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Slack bot...");
            GetLastMessage();
            while (true)
            {
                ListenForMessages(); // Continuously listen for new messages
                System.Threading.Thread.Sleep(5000); // Wait for 5 seconds before checking for new messages again
            }
        }

        static void GetLastMessage()
        {
            var client = new RestClient(slackBaseURL);
            var request = new RestRequest("conversations.history", Method.Get);
            request.AddHeader("Authorization", $"Bearer {slackBotToken}");
            request.AddParameter("channel", slackChannelIDForListen);
            request.AddParameter("limit", 1);

            var response = client.Execute<SlackApiResponse>(request);

            // Check if the response from the server is valid
            if (response.Data != null && response.Data.ok)
            {
                var messages = response.Data.messages;

                // Check if there is at least one message in the response
                if (messages != null && messages.Count > 0)
                {
                    lastMessageTimestamp = messages[0].ts; // Store the timestamp of the last message received
                }
            }
            else if (response.ErrorException != null)
            {
                Console.WriteLine(
                    $"Error retrieving last message: {response.ErrorException.Message}"
                );
            }
        }

        static void ListenForMessages()
        {
            var client = new RestClient(slackBaseURL);
            var request = new RestRequest("conversations.history", Method.Get);
            request.AddHeader("Authorization", $"Bearer {slackBotToken}");
            request.AddParameter("channel", slackChannelIDForListen);
            request.AddParameter("limit", 1);

            var response = client.Execute<SlackApiResponse>(request);

            // Check if the response from the server is valid
            if (response.Data != null && response.Data.ok)
            {
                var messages = response.Data.messages;

                // Check if there is at least one message in the response
                if (messages != null && messages.Count > 0)
                {
                    foreach (var message in messages)
                    {
                        // Check if the message is a user message and not a bot message, and if it is not the last message received
                        if (
                            message.type == "message"
                            && message.user != slackBotUserID
                            && lastMessageTimestamp != message.ts
                        )
                        {
                            lastMessageTimestamp = message.ts; // Store the timestamp of the last message received

                            var receivedMessage = message.text; // Get the text of the received message
                            receivedMessage = receivedMessage.Trim(); // Remove any leading or trailing spaces

                            var responseText =
                                "I couldn't understand you :disappointed:"
                                + Environment.NewLine
                                + "Type `-help` to find out what I can do.";

                            // Check if the message contains any specific keywords
                            if (
                                receivedMessage.Contains("hello")
                                || receivedMessage.Contains("hi")
                                || receivedMessage.Contains("selam")
                                || receivedMessage.Contains("test")
                            )
                            {
                                // If the message contains any of these keywords, respond with a greeting and a suggestion to type -help
                                responseText =
                                    "Hello! :hand: How can I help you? :cool_thinking_blob:"
                                    + Environment.NewLine
                                    + "Type -help to find out.";
                            }
                            else if (receivedMessage.Contains("-help"))
                            {
                                // If the message contains the keyword -help, respond with a list of available commands
                                responseText = "Commands : " + Environment.NewLine + "-help";
                            }
                            // Print the received message and the bot's response to the console
                            Console.WriteLine(
                                $"Received message: {message.text} => Response message: {responseText}"
                            );
                            Console.WriteLine();

                            // Send the bot's response to the channel where the message was received
                            SendMessage(message.user, responseText);
                        }
                    }
                }
            }
            else if (response.ErrorException != null)
            {
                // If an error occurs while retrieving messages, print the error message to the console
                Console.WriteLine($"Error retrieving messages: {response.ErrorException.Message}");
            }
        }

        static void SendMessage(string userId, string text)
        {
            // Create a new RestSharp RestClient instance with the base URL for the Slack API
            var client = new RestClient(slackBaseURL);

            // Create a new RestSharp RestRequest instance for the chat.postMessage API method with the appropriate parameters
            var request = new RestRequest("chat.postMessage", Method.Post);
            request.AddHeader("Authorization", $"Bearer {slackBotToken}");
            request.AddParameter("channel", slackChannelIDForListen);
            request.AddParameter("text", text);

            // Execute the RestRequest and handle any errors that occur
            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                // If an error occurs while sending the message, print the error message to the console
                Console.WriteLine($"Error sending message: {response.ErrorException.Message}");
            }
        }

        // Define a custom class to hold the response data returned by the Slack API
        class SlackApiResponse
        {
            public bool ok { get; set; }
            public List<Message> messages { get; set; }
        }

        // Define a custom class to hold the message data returned by the Slack API
        class Message
        {
            public string type { get; set; }
            public string user { get; set; }
            public string text { get; set; }
            public string ts { get; set; }
        }
    }
}
