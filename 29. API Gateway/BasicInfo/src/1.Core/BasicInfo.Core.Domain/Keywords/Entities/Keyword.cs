using BasicInfo.Core.Domain.Keywords.Events;
using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;

namespace BasicInfo.Core.Domain.Keywords.Entities;
public class Keyword : AggregateRoot
{
    #region Properties
    public KeywordStatus Status { get; set; }
    public KeywordTitle Title { get; set; }
    #endregion

    #region Constructors
    public Keyword(KeywordTitle keywordTitle)
    {
        Title = keywordTitle;
        Status = KeywordStatus.Preview;
        AddEvent(new KeywordCreated(BusinessId.Value, Title.Value));
    }
    private Keyword()
    {

    }
    #endregion

    #region Methods

    public void ChangeTitle(KeywordTitle keywordTitle)
    {
        if (Status == KeywordStatus.Inactive)
        {
            throw new InvalidEntityStateException("InvalidActionInSpecificStatus", nameof(ChangeTitle),
                nameof(KeywordStatus.Inactive));
        }

        Title = keywordTitle;
        Status = KeywordStatus.Preview;
        AddEvent(new KeywordTitleChanged(BusinessId.Value, Title.Value));
    }


    public void Active()
    {
        if (Status == KeywordStatus.Active)
        {
            throw new InvalidEntityStateException("InvalidActionInSpecificStatus", nameof(Active),
                nameof(KeywordStatus.Active));
        }
        Status = KeywordStatus.Active;
        AddEvent(new KeywordActivated(BusinessId.Value));
    }

    public void InActive()
    {
        if (Status == KeywordStatus.Inactive)
        {
            throw new InvalidEntityStateException("InvalidActionInSpecificStatus", nameof(InActive),
                nameof(KeywordStatus.Active));
        }
        Status = KeywordStatus.Inactive;
        AddEvent(new KeywordInActivated(BusinessId.Value));
    }
    #endregion
}