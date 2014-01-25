using System;
using System.Collections;
using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.Security;
using StackExchange.Profiling;

namespace POSSIBLE.ProfiledContentRepository
{
    public class ProfiledContentRepository : IContentRepository
    {
        public T Get<T>(Guid contentGuid) where T : IContentData
        {
            string stepName = string.Format("Get<{0}>[{1}]", typeof(T).Name, contentGuid);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.Get<T>(contentGuid);
            }
        }

        public T Get<T>(Guid contentGuid, ILanguageSelector selector) where T : IContentData
        {
            string stepName = string.Format("Get<{0}>[{1}]", typeof(T).Name, contentGuid);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.Get<T>(contentGuid, selector);
            }
        }

        public T Get<T>(ContentReference contentLink) where T : IContentData
        {
            string stepName = string.Format("Get<{0}>[{1}]", typeof(T).Name, contentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.Get<T>(contentLink);
            }
        }

        public T Get<T>(ContentReference contentLink, ILanguageSelector selector) where T : IContentData
        {
            string stepName = string.Format("Get<{0}>[{1}]", typeof(T).Name, contentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.Get<T>(contentLink, selector);
            }
        }

        public IEnumerable<T> GetChildren<T>(ContentReference contentLink) where T : IContentData
        {
            string stepName = string.Format("GetChildren<{0}>[{1}]", typeof(T).Name, contentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetChildren<T>(contentLink);
            }
        }

        public IEnumerable<T> GetChildren<T>(ContentReference contentLink, ILanguageSelector selector) where T : IContentData
        {
            string stepName = string.Format("GetChildren<{0}>[{1}]", typeof(T).Name, contentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetChildren<T>(contentLink, selector);
            }
        }

        public IEnumerable<T> GetChildren<T>(ContentReference contentLink, ILanguageSelector selector, int startIndex, int maxRows) where T : IContentData
        {
            string stepName = string.Format("GetChildren<{0}>[{1}:{2}:{3}]", typeof (T).Name, contentLink, startIndex, maxRows);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetChildren<T>(contentLink, selector, startIndex, maxRows);
            }
        }

        public IEnumerable<ContentReference> GetDescendents(ContentReference contentLink)
        {
            string stepName = string.Concat("GetDescendents", "{", contentLink, "}");

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetDescendents(contentLink);
            }
        }

        public IEnumerable<IContent> GetAncestors(ContentReference contentLink)
        {
            string stepName = string.Concat("GetAncestors", "{", contentLink, "}");

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetAncestors(contentLink);
            }
        }

        public IEnumerable<IContent> GetItems(IEnumerable<ContentReference> contentLinks, ILanguageSelector selector)
        {
            string stepName = string.Concat("GetItems", "{", contentLinks, "}");

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetItems(contentLinks, selector);
            }
        }

        public IEnumerable<T> GetLanguageBranches<T>(ContentReference contentLink) where T : IContentData
        {
            string stepName = string.Format("GetLanguageBranches<{0}>[{1}]", typeof(T), contentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetLanguageBranches<T>(contentLink);
            }
        }

        public T GetDefault<T>(ContentReference parentLink) where T : IContentData
        {
            string stepName = string.Format("GetDefault<{0}>[parent:{1}]", typeof(T), parentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetDefault<T>(parentLink);
            }
        }

        public T GetDefault<T>(ContentReference parentLink, ILanguageSelector languageSelector) where T : IContentData
        {
            string stepName = string.Format("GetDefault<{0}>[parent:{1}]", typeof(T), parentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetDefault<T>(parentLink, languageSelector);
            }
        }

        public T GetDefault<T>(ContentReference parentLink, int contentTypeID, ILanguageSelector languageSelector) where T : IContentData
        {
            string stepName = string.Format("GetDefault<{0}>[parent:{1}:{2}]", typeof(T), parentLink, contentTypeID);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetDefault<T>(parentLink, contentTypeID, languageSelector);
            }
        }

        public T CreateLanguageBranch<T>(ContentReference contentLink, ILanguageSelector languageSelector, AccessLevel access) where T : IContentData
        {
            string stepName = string.Format("CreateLanguageBranch<{0}>[{1}]", typeof(T), access);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.CreateLanguageBranch<T>(contentLink, languageSelector, access);
            }
        }

        public ContentReference Copy(ContentReference source, ContentReference destination, AccessLevel requiredSourceAccess, AccessLevel requiredDestinationAccess, bool publishOnDestination)
        {
            string stepName = string.Format("Copy [from:{0}, to:{1}]", source, destination);

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.Copy(source, destination, requiredSourceAccess, requiredDestinationAccess, publishOnDestination);
            }
        }

        public void Delete(ContentReference contentLink, bool forceDelete, AccessLevel access)
        {
            string stepName = string.Format("Delete [{0}]", contentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                DataFactory.Instance.Delete(contentLink, forceDelete, access);
            }
        }

        public void DeleteChildren(ContentReference contentLink, bool forceDelete, AccessLevel access)
        {
            string stepName = string.Format("DeleteChildren [{0}]", contentLink);

            using (MiniProfiler.Current.Step(stepName))
            {
                DataFactory.Instance.DeleteChildren(contentLink, forceDelete, access);
            }
        }

        public void DeleteLanguageBranch(ContentReference contentLink, string languageBranch, AccessLevel access)
        {
            string stepName = string.Format("DeleteLanguageBranch [{0}:{1}:{2}]", contentLink, languageBranch, access);

            using (MiniProfiler.Current.Step(stepName))
            {
                DataFactory.Instance.DeleteLanguageBranch(contentLink, languageBranch, access);
            }
        }

        public void Move(ContentReference contentLink, ContentReference destination, AccessLevel requiredSourceAccess, AccessLevel requiredDestinationAccess)
        {
            string stepName = string.Format("Move[{0}:{1}:{2}:{3}]", contentLink, destination, requiredSourceAccess, requiredDestinationAccess);

            using (MiniProfiler.Current.Step(stepName))
            {
                DataFactory.Instance.Move(contentLink, destination, requiredSourceAccess, requiredDestinationAccess);
            }
        }

        public void MoveToWastebasket(ContentReference contentLink, string deletedBy)
        {
            string stepName = string.Concat("MoveToWastebasket", "{", contentLink, deletedBy, "}");
            
            using (MiniProfiler.Current.Step(stepName))
            {
                DataFactory.Instance.MoveToWastebasket(contentLink, deletedBy);
            }
        }

        public void MoveToWastebasket(ContentReference contentLink)
        {
            string stepName = string.Concat("MoveToWastebasket", "{", contentLink, "}");

            using (MiniProfiler.Current.Step(stepName))
            {
                DataFactory.Instance.MoveToWastebasket(contentLink);
            }
        }

        public ContentReference Save(IContent content, SaveAction action, AccessLevel access)
        {
            string stepName = string.Concat("Save", "{", content.ContentLink, ":", access, "}");

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.Save(content, action, access);
            }
        }

        public IEnumerable<ReferenceInformation> GetReferencesToContent(ContentReference contentLink, bool includeDecendents)
        {
            string stepName = string.Concat("GetReferencesToContent", "{", contentLink, ":", includeDecendents, "}");

            using (MiniProfiler.Current.Step(stepName))
            {
                return DataFactory.Instance.GetReferencesToContent(contentLink, includeDecendents);
            }
        }

        public IEnumerable<IContent> ListDelayedPublish()
        {
            using (MiniProfiler.Current.Step("ListDelayedPublish"))
            {
                 List<IContent> contents = new List<IContent>();
                 DataFactory.Instance.ProviderMap.Iterate((System.Action<ContentProvider>) (contentProvider => contents.AddRange(contentProvider.ListDelayedPublish())));
                 return (IEnumerable<IContent>) contents;
            }
        }


    }
}