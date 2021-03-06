import graderClient from '../GraderClient';

const getCoursesAsync = () => {
    return graderClient({
        method: "get",
        url: `https://localhost:44335/odata/course`,
    });
}

export {
    getCoursesAsync
}