using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria, Criteria<TItem> other)
    {
	    return new Conjunction<TItem>(criteria, other);
    }

    public static Criteria<TItem> Or<TItem>(this Criteria<TItem> criteria, Criteria<TItem> other)
    {
	    return new Alternative<TItem>(criteria, other);
    }
}