import graderClient from '../GraderClient';

const getCoursesAsync = () => {
    return graderClient({
        method: "get",
        url: `/odata/course`,
    });
}

export {
    getCoursesAsync
}