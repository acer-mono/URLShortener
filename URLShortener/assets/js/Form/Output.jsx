import React from 'react';

export default props => {
    if (!props.response || !props.response.url) {
        return '';
    }
    
    return (
        <div className="output">
            <div className="output__short-url">{props.response.url}</div>
            <button
                className="output__copy"
                type="button"
                title="Copy to Clipboard">Copy to Clipboard</button>
        </div>
    );
};