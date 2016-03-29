﻿using Rg.ServiceCore.DbModel;
using Rg.ServiceCore.Operations;
using Rg.ApiTypes;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rg.Api.Controllers
{
    public class CommentController : ApiControllerBase
    {
        /// <summary>
        /// Likes or unlikes a comment.
        /// </summary>
        /// <param name="commentId">
        /// The comment for which to set or remove a 'like'.
        /// </param>
        /// <param name="likeRequest">
        /// Specifies the kind of 'like', and whether we're setting or removing it.
        /// </param>
        /// <returns></returns>
        [Route("api/Comments/{commentId}/Like")]
        public async Task PostLike(int commentId, LikeRequest likeRequest)
        {
            UserInfo user = await GetUserInfoAsync();
            HttpStatusCode result = await CommentOperations.AddOrRemoveCommentLikeAsync(
                DbContext, user.UserInfoId, commentId, likeRequest);
            result.ThrowHttpResponseExceptionIfNotSuccessful();
        }
    }
}
