export class BlogComment {
    constructor(
        blogCommentId: number,
        blogId: number,
        content: string,
        username: string,
        applicationUserId: number,
        publishDate: Date,
        updateDate: Date,
        parentBlogCommentId?: number
    ) {}
}