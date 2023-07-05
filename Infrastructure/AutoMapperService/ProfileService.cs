using AutoMapper;
using Domain.Dtos.CommentDtos;
using Domain.Dtos.DirectMessageDtos;
using Domain.Dtos.ExploreDtos;
using Domain.Dtos.FollowerDtos;
using Domain.Dtos.HashtagDtos;
using Domain.Dtos.LikeDtos;
using Domain.Dtos.NotificationDtos;
using Domain.Dtos.PostDtos;
using Domain.Dtos.PostHashtagDtos;
using Domain.Dtos.SavedPostDtos;
using Domain.Dtos.StoryDtos;
using Domain.Dtos.UserDtos;
using Domain.Entities;

namespace Infrastructure.AutoMapperService;

public class ProfileService : Profile
{
    public ProfileService()
    {
        CreateMap<AddCommentDto, Comment>();
        CreateMap<Comment, GetCommentDto>();
        
        CreateMap<AddDirectMessageDto, DirectMessage>();
        CreateMap<DirectMessage, GetDirectMessageDto>();
        
        CreateMap<AddExploreDto, Explore>();
        CreateMap<Explore, GetExploreDto>();
        
        CreateMap<AddFollowerDto, Follower>();
        CreateMap<Follower, GetFollowerDto>();
        
        CreateMap<AddHashtagDto, Hashtag>();
        CreateMap<Hashtag, GetHashtagDto>();
        
        CreateMap<AddLikeDto, Like>();
        CreateMap<Like, GetLikeDto>();
        
        CreateMap<AddNotificationDto, Notification>();
        CreateMap<Notification, GetNotificationDto>();
        
        CreateMap<AddPostDto, Post>();
        CreateMap<Post, GetPostDto>();
        
        CreateMap<AddPostHashtagDto, PostHashtag>();
        CreateMap<PostHashtag, GetPostHashtagDto>();
        
        CreateMap<AddSavedPostDto, SavedPost>();
        CreateMap<SavedPost, GetSavedPostDto>();
        
        CreateMap<AddStoryDto, Story>();
        CreateMap<Story, GetStoryDto>();
        
        CreateMap<AddUserDto, User>();
        CreateMap<User, GetUserDto>();
    }
}