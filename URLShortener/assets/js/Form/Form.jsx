import React, { useState } from 'react';
import UserInput from "./UserInput";
import Output from './Output';

export default props => {
    const [response, setResponse] = useState('');
    
    return (
        <div className="form">
            <UserInput onSubmit={submitOriginalUrl(props.fetchShortUrl, setResponse)} />
            <Output response={response} />
        </div>
    );
};

function submitOriginalUrl(fetchShortUrl, setResponse) {
    return async originalUrl => {
        setResponse(await fetchShortUrl(originalUrl));
    };
}
