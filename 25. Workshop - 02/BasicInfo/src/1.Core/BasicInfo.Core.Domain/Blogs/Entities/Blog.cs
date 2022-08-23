﻿using BasicInfo.Core.Domain.Blogs.Events;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Core.Domain.ValueObjects;

namespace BasicInfo.Core.Domain.Blogs.Entities
{
    public class Blog:AggregateRoot
    {
        #region Properties
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        #endregion

        #region Constructors
        private Blog()
        {

        }
        public Blog(BusinessId businessId, Title title, Description description)
        {
            BusinessId = businessId;
            Title = title;
            Description = description;
            AddEvent(new BlogCreated(businessId.Value.ToString(), Title.Value, Description.Value));
        } 
        #endregion

    }
}
