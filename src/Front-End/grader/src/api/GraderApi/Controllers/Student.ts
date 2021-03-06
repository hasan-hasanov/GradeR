import graderClient from '../GraderClient';

const getStudentsAsync = () => {
    return graderClient({
        method: "get",
        url: `odata/student`,
    });
}

export {
    getStudentsAsync
}