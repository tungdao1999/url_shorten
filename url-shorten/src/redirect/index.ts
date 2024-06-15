import { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import api from '../api/api';

const RedirectHandler = () => {
  const { hash } = useParams<{ hash: string }>();

  useEffect(() => {
    const handleRedirect = async () => {
      try {
        const response = await api.getApiData('Redirect/' + hash);
        if (response.redirectUrl) {
          // If the original URL exists, redirect to it
          window.location.href = response.redirectUrl;
        } else {
          // If the original URL does not exist, redirect to an error page or show an error message
          window.location.href = '/error'; 
        }
      } catch (error) {
        // Handle the error or perform any necessary actions
        window.location.href = '/error';
      }
    };

    handleRedirect();
  }, [hash]);

  return null;
};

export default RedirectHandler;
