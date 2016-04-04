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
        oneAtATime = true;

        groups = [
            {
                title: 'Dynamic Group Header - 1',
                content: 'Dynamic Group Body - 1'
            },
            {
                title: 'Dynamic Group Header - 2',
                content: 'Dynamic Group Body - 2'
            }
        ];

        items = ['Item 1', 'Item 2', 'Item 3'];

        addItem() {
            var newItemNo = this.items.length + 1;
            this.items.push('Item ' + newItemNo);
        };

        status = {
            isFirstOpen: true,
            isFirstDisabled: false,
            isBottomOpen: false
        };

        constuctor(acc: ng.ui.bootstrap.IAccordionConfig) {
            acc.closeOthers = true;
        }
    }

    export class TestPostController {
        title: string;

        creator;

        content: string;

        comments;

        score: number;

        constructor() {

            this.score = 50;

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
