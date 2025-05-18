# Hiking
SocialApp/

├── src/

│   ├── SocialApp.Domain/

│   │   ├── Entities/

│   │   │   ├── User.cs

│   │   │   ├── Post.cs

│   │   │   ├── Comment.cs

│   │   │   ├── Friendship.cs

│   │   │   ├── ChatMessage.cs

│   │   │   └── ChatGroup.cs

│   │   ├── Events/

│   │   │   ├── PostCreatedEvent.cs

│   │   │   ├── FriendRequestAcceptedEvent.cs

│   │   │   └── MessageSentEvent.cs

│   │   ├── ValueObjects/

│   │   │   ├── PostContent.cs

│   │   │   ├── UserStatus.cs

│   │   │   └── MessageStatus.cs

│   │   ├── Interfaces/

│   │   │   ├── IUserRepository.cs

│   │   │   ├── IPostRepository.cs

│   │   │   └── ...

│   │   └── Services/

│   │       └── DomainServices/

│   ├── SocialApp.Application/

│   │   ├── Commands/

│   │   │   ├── Posts/

│   │   │   │   ├── CreatePostCommand.cs

│   │   │   │   └── CreatePostCommandHandler.cs

│   │   │   ├── Comments/

│   │   │   └── ...

│   │   ├── Queries/

│   │   │   ├── Posts/

│   │   │   │   ├── GetPostsQuery.cs

│   │   │   │   └── GetPostsQueryHandler.cs

│   │   │   └── ...

│   │   ├── DTOs/

│   │   ├── Mapping/

│   │   ├── Validators/

│   │   ├── Behaviors/

│   │   └── Services/

│   │       ├── IChatService.cs

│   │       ├── ChatService.cs

│   │       └── ...

│   ├── SocialApp.Infrastructure/

│   │   ├── Persistence/

│   │   │   ├── ApplicationDbContext.cs

│   │   │   ├── Configurations/

│   │   │   └── Repositories/

│   │   ├── Identity/

│   │   ├── Services/

│   │   │   ├── FileStorageService.cs

│   │   │   ├── CacheService.cs

│   │   │   └── ...

│   │   └── MessageBroker/

│   ├── SocialApp.API/

│   │   ├── Controllers/

│   │   │   ├── PostsController.cs

│   │   │   ├── CommentsController.cs

│   │   │   ├── FriendshipsController.cs

│   │   │   └── ...

│   │   ├── Hubs/

│   │   │   ├── ChatHub.cs

│   │   │   └── NotificationHub.cs

│   │   ├── Middleware/

│   │   ├── Extensions/

│   │   └── Program.cs

│   └── SocialApp.Shared/

│       ├── Results/

│       ├── Extensions/

│       └── Constants/

└── tests/

├── SocialApp.Domain.Tests/

├── SocialApp.Application.Tests/

├── SocialApp.Infrastructure.Tests/

└── SocialApp.API.Tests/