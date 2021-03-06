import graderClient from '../GraderClient';

const getGradesAsync = () => {
    return graderClient({
        method: "get",
        url: `https://localhost:44335/odata/grade`,
    });
}

export {
    getGradesAsync
}