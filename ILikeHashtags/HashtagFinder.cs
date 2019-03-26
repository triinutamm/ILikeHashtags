using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using InstaSharper.API;
using InstaSharper.Classes;

namespace ILikeHashtags
{
    internal class HashtagFinder : IDemoSample
    {
        private static readonly int _maxDescriptionLength = 20;

        private readonly IInstaApi _instaApi;

        public HashtagFinder(IInstaApi instaApi)
        {
            _instaApi = instaApi;
        }

        public async Task DoShow()
        {

            var tagFeed = await _instaApi.GetTagFeedAsync("quadcopter", PaginationParameters.MaxPagesToLoad(5));
            if (tagFeed.Succeeded)
            {
                Console.WriteLine(
                    $"Tag feed items (in {tagFeed.Value.MediaItemsCount} pages) [{currentUser.Value.UserName}]: {tagFeed.Value.Medias.Count}");
                foreach (var media in tagFeed.Value.Medias)
                    ConsoleUtils.PrintMedia("Tag feed", media, _maxDescriptionLength);
            }
        }
    }
}