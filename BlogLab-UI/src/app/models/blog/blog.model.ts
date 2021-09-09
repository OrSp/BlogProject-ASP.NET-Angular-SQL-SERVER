export class Blog {
    constructor(
        blogId: number,
        title: string,
        content: string,
        applicationUserId: number,
        username: string,
        publishDate: Date,
        updateDate: Date,
        deleteConfirm: boolean = false,
        photoId?: number
    ) {}

}