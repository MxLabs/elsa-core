﻿using Elsa.Activities.Telnyx.Activities;
using Elsa.Services;

namespace Elsa.Activities.Telnyx.Providers.Bookmarks
{
    public class AnswerCallBookmark : IBookmark
    {
    }

    public class AnswerCallBookmarkProvider : DefaultBookmarkProvider<AnswerCallBookmark, AnswerCall>
    {
    }
}