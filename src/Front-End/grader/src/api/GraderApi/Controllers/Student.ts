import graderClient from '../GraderClient';

const getStudentsAsync = () => {
    return graderClient({
        method: "get",
        url: `https://localhost:44335/odata/student`,
    });
}

export {
    getStudentsAsync
}