import React from 'react';
import Card from '../components/card';
import Input from '../components/input';
import Button from '../components/button';
import api from '../api/api';
import LoadingIcon from '../components/loading';

const customInputStyle = {
  width: '600px',
};

interface ShortResponse {
  shortedUrl: string;
}
interface ShortRequest {
  originalUrl: string;
}

const Short: React.FC = () => {
  const [showResults, setShowResults] = React.useState(false);
  const [shortedUrl, setShortedUrl] = React.useState('');
  const [originalUrl, setOriginalUrl] = React.useState('');
  const [isLoading, setIsLoading] = React.useState(false);

  const handleShortClick = () => {
    setShortedUrl('');
    setIsLoading(true);
    const shortRequest: ShortRequest = { originalUrl };

    api.postApiData('shorten', shortRequest)
     .then((response: ShortResponse) => {
        setShortedUrl(window.location.host + '/' +response.shortedUrl);
        setShowResults(true);
      })
     .catch((error: any) => {
        console.log(error);
      })
     .finally(() => {
        setIsLoading(false); // Set isLoading to false after the API call
      });
  };

  const copyShortedUrl = () => {
    alert("Copied to clipboard");
    navigator.clipboard.writeText(shortedUrl);
  };

  const handleOnInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setOriginalUrl(event.target.value);
  };

  return (
    <Card as={React.Fragment}>
      <h2 className='text-blue'>SHORT YOUR URL</h2>
      <div className='input-container'>
        <Input customstyle={customInputStyle} name="Link" onChange={handleOnInputChange}></Input>
        <Button name="Short" onClick={handleShortClick}></Button>
      </div>
      {isLoading ? (
        <LoadingIcon /> 
      ) :showResults? (
        <>
          <h2 className='text-blue'>YOUR NEW URL</h2>
          <div className='input-container'>
            <Input customstyle={customInputStyle} name="Link" value={shortedUrl}></Input>
            <Button name="Copy" onClick={copyShortedUrl}></Button>
          </div>
        </>
      ) : (<></>)}
    </Card>
  );
};

export default Short;