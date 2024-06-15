import  './index.css'

interface InputProps {
  name: string;
  customstyle: React.CSSProperties;
  onChange?: React.ChangeEventHandler<HTMLInputElement>;
  value?: string
}

const Input: React.FC<InputProps> = ({ name,value, onChange,...props }) => {
  return <input onChange={onChange} style={props.customstyle} {...props} placeholder={name} value={value}></input>
}

export default Input;