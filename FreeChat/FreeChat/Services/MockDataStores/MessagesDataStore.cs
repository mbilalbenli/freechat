﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Services.MockDataStores
{
    public class MessagesDataStore : IMessageDataStore
    {
        readonly List<Message> _messages;

        public MessagesDataStore(Conversation conversation)
        {
            _messages = new List<Message>();

            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                Content = "I was at your office yesterday.",
                CreationDate = DateTime.Now,
                ISent = false,
                SenderId = conversation.Peer.Id,
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                Content = "Ooh really ?",
                CreationDate = DateTime.Now + TimeSpan.FromMinutes(2),
                ISent = true,
                SenderId = conversation.UserIds[0],
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                Content = "Yeah. But you were not arround",
                CreationDate = DateTime.Now + TimeSpan.FromMinutes(10),
                ISent = false,
                SenderId = conversation.Peer.Id,
            });
            conversation.LastMessage.CreationDate = DateTime.Now + TimeSpan.FromHours(6);
            _messages.Add(conversation.LastMessage);
        }

        public Task<bool> AddItemAsync(Message item)
        {
            _messages.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetMessagesForConversation(string conversationId)
        {
            return Task.FromResult(_messages.Where(m => m.ConversationId == conversationId));
        }

        public Task<bool> UpdateItemAsync(Message item)
        {
            throw new NotImplementedException();
        }
    }
}