import graderClient from '../GraderClient';

const getGradesAsync = () => {
    return graderClient({
        method: "get",
        url: `odata/grade`,
    });
}

export {
    getGradesAsync
}