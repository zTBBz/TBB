import React from 'react';
import InventorySlot, { Props as InventorySlotProps } from '../InventorySlot';
import styles from './index.module.css';

export type Props = {
  title: React.ReactNode,
  description: React.ReactNode,
  slot: React.ReactNode,
  unlockCost?: React.ReactNode,
  CCPV?: React.ReactNode,
  extra?: React.ReactNode,
  audio?: React.ReactNode,
  audio2?: React.ReactNode,
}

export default function ({title, description, slot, unlockCost, CCPV, extra, audio, audio2}: Props) : JSX.Element {

  return (
    <div className={styles.container}>
      <div className={styles.title}>{title}</div>
      <div className={styles.description}>{description}</div>
      <div className={styles.slot}>{slot}</div>
      <div className={styles.costs}>
        {<b>Unlock Cost: </b>}{unlockCost}<br/>
        {<b>CCPV: </b>}{CCPV}
      </div>
      <div className={styles.extra}>{extra}</div>
      <div className={styles.audio}>{audio}</div>
      <div className={styles.audio2}>{audio2}</div>
    </div>
  );
}
