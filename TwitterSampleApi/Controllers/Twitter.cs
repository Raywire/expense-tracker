using Microsoft.AspNetCore.Mvc;

namespace TwitterSampleApi.Controllers
{

    [ApiController]
    [Route("api/twitters")]
    public class Twitter : ControllerBase
    {
        [HttpGet("tweets")]
        public IActionResult get()
        {
            List<Models.TwitterSampleApi> tweets = new List<Models.TwitterSampleApi>();
            tweets.Add(new Models.TwitterSampleApi()
                { Id = 1, metin = "a", sender = "ali", sender_username = "klidnos" }); 
            return Ok(tweets);

        }
        [HttpPost("send_tweet")]
        public IActionResult Create(Models.TwitterSampleApi tweet)
        {
            List<Models.TwitterSampleApi> tweets = new List<Models.TwitterSampleApi>();
            tweets.Add(tweet);
            return Ok(tweets);
        }
    }
}

