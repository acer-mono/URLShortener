import React, { useState } from 'react';
import UserInput from "./UserInput";
import Output from './Output';

export default ({fetchShortUrl}) => {
    const [response, setResponse] = useState({});

    const submitOriginalUrl = async originalUrl => {
        setResponse({});
        setResponse(await fetchShortUrl(originalUrl));
    };
    
    return (
        <div className="form">
            <UserInput onSubmit={submitOriginalUrl} />
            <Output response={response} />
        </div>
    );
};
