namespace solo.Controllers {

    export class HomeController {
        
    }

    export class LogInController {

    }

    export class AllBoardsController {
        
    }

    export class BoardController {
        
    }

    export class PostController {
        
    }

    export class UserController {

    }

    export class TestHomeController {

    }

    export class TestBoardController {

    }

    export class TestPostController {
        title: string;

        creator;

        content: string;

        comments;

        constructor() {

            this.creator = { name: "poster" };

            this.title = "post title";

            this.content = "post content";

            this.comments = [
                {
                    creator: { name: "user1" },
                    content: "content1",
                    score: 10,
                    comments: [
                        {
                            creator: { name: "user 2" },
                            content: "content2",
                            score: 20,
                            comments: [
                                {
                                    creator: { name: "user3" },
                                    content: "content3",
                                    score: 2
                                }
                            ]
                        }, {
                            creator: { name: "user4" },
                            content: "content4",
                            score: 7
                        }
                    ]
                },
                {
                    creator: { name: "user5" },
                    content: "content5",
                    score: -5
                },
                {
                    creator: { name: "user6" },
                    content: "content6",
                    score: 2,
                    comments: [
                        {
                            creator: null,
                            content: "content7",
                            score: 2,
                            comments: [
                                {
                                    creator: { name: "user8" },
                                    content: "content8",
                                    score: 1
                                }
                            ]
                        }
                    ]
                }
            ];

        }
    }

}
