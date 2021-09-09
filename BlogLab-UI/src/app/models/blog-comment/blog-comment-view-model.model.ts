export class BlogCommentViewModel {
    constructor(
        parentBlogCommentId: number,
        blogCommentId: number,
        blogId: number,
        content: string,
        username: string,
        applicationUserId: number,
        publishDate: Date,
        updateDate: Date,
        isEditable: boolean = false,
        deleteConfirm: boolean = false,
        isReplying: boolean = false,
        comments: BlogCommentViewModel[]
    ) {}
}